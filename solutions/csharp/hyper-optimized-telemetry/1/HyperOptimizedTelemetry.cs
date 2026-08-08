public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading) 
    {
        var targetType = GetSmallestIntegralType(reading);
        byte[] bytes = targetType switch
        {
            Type t when t == typeof(ushort) => BitConverter.GetBytes((ushort)reading),
            Type t when t == typeof(short)  => BitConverter.GetBytes((short)reading),
            Type t when t == typeof(uint)   => BitConverter.GetBytes((uint)reading),
            Type t when t == typeof(int)    => BitConverter.GetBytes((int)reading),
            _                               => BitConverter.GetBytes(reading) // long
        };
        var result = new byte[9];
        result[0] = (byte)(IsSigned(targetType) ? 256 - bytes.Length : bytes.Length);
        Array.Copy(bytes, 0, result, 1, bytes.Length);
        return result;
    }

    public static long FromBuffer(byte[] buffer)
    {
        byte prefix = buffer[0];
        bool isSigned = (prefix & 0x80) != 0;
        int byteLength = isSigned ? 256 - prefix : prefix;
        return (long) ((isSigned, byteLength) switch
        {
            (true, 2)  => BitConverter.ToInt16(buffer, 1),
            (false, 2) => BitConverter.ToUInt16(buffer, 1),
            (true, 4)  => BitConverter.ToInt32(buffer, 1),
            (false, 4) => BitConverter.ToUInt32(buffer, 1),
            (true, 8)  => BitConverter.ToInt64(buffer, 1),
            _ => 0
        });
    }

    public static bool IsSigned(Type t) => t == typeof(short) || t == typeof(int) || t == typeof(long);

    public static Type GetSmallestIntegralType(long value)
    {
        return value switch
        {
            >=(long)uint.MaxValue + 1   and <=long.MaxValue            => typeof(long),
            >=(long)int.MaxValue + 1    and <=uint.MaxValue            => typeof(uint),
            >=(long)ushort.MaxValue + 1 and <=int.MaxValue             => typeof(int),
            >=0                         and <=ushort.MaxValue          => typeof(ushort),
            >=short.MinValue            and <=-1                       => typeof(short),
            >=int.MinValue              and <=(long)short.MinValue - 1 => typeof(int),
            >=long.MinValue             and <=(long)int.MinValue - 1   => typeof(long)
        };
    }
}
