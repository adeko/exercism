pub fn raindrops(n: u32) -> String {
    let rules = [(3, "Pling"), (5, "Plang"), (7, "Plong")];
    let mut output = String::new();
    for (div, sound) in rules { if n % div == 0 { output.push_str(sound); } }
    if output.is_empty() { n.to_string() } else { output }
}
