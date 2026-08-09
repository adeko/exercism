const STUDENTS: [&str; 12] = [
    "Alice", "Bob", "Charlie", "David", "Eve", "Fred",
    "Ginny", "Harriet", "Ileana", "Joseph", "Kincaid", "Larry",
];

fn seed_name(c: char) -> Option<&'static str> {
    match c {
        'G' => Some("grass"),
        'C' => Some("clover"),
        'R' => Some("radishes"),
        'V' => Some("violets"),
        _ => None,
    }
}

pub fn plants(diagram: &str, student: &str) -> Vec<&'static str> {
    let Some(index) = STUDENTS.iter().position(|&x| x == student) else {
        return vec![];
    };

    let index = index * 2;

    let diagram: Vec<Vec<char>> = diagram
        .lines()
        .map(|line| line.chars().collect())
        .collect(); 

    diagram
        .iter()
        .flat_map(|row| [row.get(index), row.get(index + 1)])
        .flatten()
        .copied()
        .filter_map(seed_name)
        .collect()
}
