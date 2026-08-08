pub fn build_proverb(list: &[&str]) -> String {
    if list.is_empty() { return String::new(); }
    let mut proverb: String = list.windows(2)
        .map(|w| format!("For want of a {} the {} was lost.\n", w[0], w[1]))
        .collect();
    proverb.push_str(&format!("And all for the want of a {}.", list[0]));
    proverb
}
