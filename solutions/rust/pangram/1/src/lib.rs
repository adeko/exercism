use std::collections::HashSet;

/// Determine whether a sentence is a pangram.
pub fn is_pangram(sentence: &str) -> bool {
    let mut seen = HashSet::new();
    sentence.chars()
        .filter(|&c| c.is_ascii_alphabetic())
        .for_each(|c| { seen.insert(c.to_ascii_lowercase()); });
    seen.len() == 26
}
