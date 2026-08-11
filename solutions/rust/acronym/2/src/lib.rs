pub fn abbreviate(phrase: &str) -> String {
    phrase
        .split(|c: char| c == '-' || c.is_whitespace())
        .filter_map(|word| {
            if word.is_empty() { return None; }
            let mut chars = word.chars();
            let first = chars.find(|c| c.is_alphabetic())?;
            let mut buffer = String::with_capacity(word.len());
            buffer.extend(first.to_uppercase());       
            let mut is_prev_upper = true;
            for c in chars {
                let is_current_upper = c.is_uppercase(); 
                if is_current_upper && !is_prev_upper {
                    buffer.push(c);
                }
                is_prev_upper = is_current_upper;
            }
            Some(buffer) 
        })
        .collect()
}
