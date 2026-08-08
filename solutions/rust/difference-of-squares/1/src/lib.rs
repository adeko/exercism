pub fn square_of_sum(n: u32) -> u32 {
    // (1..=n).sum::<u32>().pow(2)
    (n * (n + 1) / 2).pow(2) // Carl Friedrich Gauss's formula
}

pub fn sum_of_squares(n: u32) -> u32 {
    // (1..=n).map(|i| i * i).sum::<u32>()
    n * (n + 1) * (2 * n + 1) / 6 // Square Pyramidal Number formula
}

pub fn difference(n: u32) -> u32 {
    square_of_sum(n) - sum_of_squares(n)
}
