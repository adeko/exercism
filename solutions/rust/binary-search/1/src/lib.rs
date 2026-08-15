pub fn find(array: &[i32], key: i32) -> Option<usize> {
    let mut array = array;
    let mut offset = 0;
    while !array.is_empty() {
        let i = array.len() / 2;
        if array[i] == key { 
            return Some(offset + i); 
        }
        if array[i] < key { 
            offset += i + 1;
            array = &array[i + 1..] 
        } else { 
            array = &array[..i] 
        }
    }
    None
}
