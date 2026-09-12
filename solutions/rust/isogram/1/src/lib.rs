use std::collections::HashSet;

pub fn check(candidate: &str) -> bool {
    let mut map = HashSet::new();
    candidate
        .chars()
        .filter(|&c| c != ' ' && c != '-') 
        .flat_map(|c| c.to_lowercase())
        .all(|c| map.insert(c))
}
