/// Determines whether the supplied string is a valid ISBN number
pub fn is_valid_isbn(isbn: &str) -> bool {
    let chars: Vec<char> = isbn.chars().filter(|&c| c != '-').collect();
    if chars.len() != 10 {
        return false;
    }
    let mut sum = 0;
    for (idx, &c) in chars.iter().enumerate() {
        let i = 10 - idx;        
        let value = match c {
            'X' if idx == 9 => 10,
            '0'..='9' => c.to_digit(10).unwrap() as usize,
            _ => return false,
        };
        sum += value * i;
    }
    sum % 11 == 0
}
