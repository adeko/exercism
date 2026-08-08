pub fn collatz(n: u64) -> Option<u64> {
    if n == 0 { return None; }
    let mut n = n;
    let mut i = 0;
    while n > 1 {
        n = if n % 2 == 0 { n / 2 } else { n * 3 + 1 };
        i += 1;
    }
    Some(i)
}
