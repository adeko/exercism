pub fn factors(n: u64) -> Vec<u64> {
    let mut n = n;
    let mut pf = Vec::new();

    if n < 2 {
        return pf;
    }
    
    let mut prime = 2;
    while n % prime == 0 {
        pf.push(prime);
        n /= prime;
    }

    prime = 3;
    while prime * prime <= n {
        while n % prime == 0 {
            pf.push(prime);
            n /= prime;
        }
        prime += 2;
    }

    if n > 1 {
        pf.push(n);
    }

    pf    
}
