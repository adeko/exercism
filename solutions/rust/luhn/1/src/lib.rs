/// Check a Luhn checksum.
pub fn is_valid(code: &str) -> bool {
    let mut sum = 0;
    let mut count = 0;

    for (idx, c) in code
        .chars()
        .filter(|&c| c != ' ')
        .rev()
        .enumerate() {
        match c {
            '0'..='9' => {
                let mut digit = c.to_digit(10).unwrap();
                if idx % 2 == 1 {
                    digit *= 2;
                    if digit > 9 { digit -= 9; }
                }
                sum += digit;
                count += 1;
            }
            _ => return false, 
        }
    }

    sum % 10 == 0 && count > 1
}
