use std::collections::HashSet;

pub fn anagrams_for<'a>(word: &str, possible_anagrams: &[&'a str]) -> HashSet<&'a str> {
    let word_lc = word.to_lowercase();
    let mut word_chars_sorted: Vec<char> = word_lc.chars().collect();
    word_chars_sorted.sort_unstable();

    possible_anagrams
        .iter()
        .filter(|&&anagram| {
            let anagram_lc = anagram.to_lowercase();
            if anagram_lc.len() != word_lc.len() || anagram_lc == word_lc {
                return false; 
            }    
            let mut anagram_chars_sorted: Vec<char> = anagram_lc.chars().collect();
            anagram_chars_sorted.sort_unstable();
            anagram_chars_sorted == word_chars_sorted
        })
        .copied()
        .collect()
}
