use std::collections::HashSet;

pub fn sum_of_multiples(limit: u32, factors: &[u32]) -> u32 {
    let mut unique = HashSet::new();
    for &i in factors {
        if i == 0 { continue; }
        let mut n = 1;
        while i * n < limit {
            unique.insert(i * n);
            n += 1;
        }
    }
    unique.into_iter().sum()
}