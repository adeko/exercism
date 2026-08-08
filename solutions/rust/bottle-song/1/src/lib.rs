use std::fmt::Write;

pub fn recite(start_bottles: u32, take_down: u32) -> String {
    let mut song = String::new();
    let words = ["No", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten"];
    let end_bottles = start_bottles - take_down + 1;

    for i in (end_bottles..=start_bottles).rev() {
        let current_word = words[i as usize];
        let next_word = words[(i - 1) as usize].to_lowercase();
        
        let current_plural = if i == 1 { "" } else { "s" };
        let next_plural = if i - 1 == 1 { "" } else { "s" };

        let _ = writeln!(&mut song,
"{} green bottle{} hanging on the wall,
{} green bottle{} hanging on the wall,
And if one green bottle should accidentally fall,
There'll be {} green bottle{} hanging on the wall.",
            current_word, current_plural,
            current_word, current_plural,
            next_word, next_plural
        );

        if i > end_bottles {
            let _ = writeln!(&mut song);
        }
    }

    song
}
