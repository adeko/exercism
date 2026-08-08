pub fn nth(n: u32) -> u32 {
    // Shadow 0-indexed 'n' to a 1-based usize
    let n = (n + 1) as usize;
    
    if n == 1 {
        return 2;
    }

    // Sieve of Eratosthenes

    let f = n as f64;
    let limit = (f * f.ln() + f * f.ln().ln()).ceil() as usize + 3;

    let mut sieve = vec![true; limit];
    sieve[0] = false;
    sieve[1] = false;

    let limit_sqrt = (limit as f64).sqrt() as usize;
    for i in 2..=limit_sqrt {
        if sieve[i] {
            let mut j = i * i;
            while j < limit {
                sieve[j] = false;
                j += i;
            }
        }
    }

    let mut count = 0;
    for (idx, is_prime) in sieve.into_iter().enumerate() {
        if is_prime {
            count += 1;
            if count == n {
                return idx as u32;
            }
        }
    }

    panic!("Error: Something went wrong.");
}
