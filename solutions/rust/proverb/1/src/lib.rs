pub fn build_proverb(list: &[&str]) -> String {
    if list.is_empty() {
        return String::new();
    }    
    let mut proverb = Vec::new();    
    for pair in list.windows(2) {
        proverb.push(format!("For want of a {} the {} was lost.", pair[0], pair[1]));
    }    
    proverb.push(format!("And all for the want of a {}.", list[0]));    
    proverb.join("\n")
}
