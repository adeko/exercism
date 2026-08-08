#[derive(Debug, PartialEq, Eq)]
pub enum Comparison {
    Equal,
    Sublist,
    Superlist,
    Unequal,
}

pub fn sublist(first_list: &[i32], second_list: &[i32]) -> Comparison {
    if first_list == second_list { return Comparison::Equal; }
    if first_list.is_empty() { return Comparison::Sublist; }
    if second_list.is_empty() { return Comparison::Superlist; }

    let (short_list, long_list, is_sublist) = if first_list.len() < second_list.len() { 
        (first_list, second_list, true) 
    } else { 
        (second_list, first_list, false) 
    };

    if long_list.windows(short_list.len()).any(|w| w == short_list) { 
        if is_sublist { return Comparison::Sublist; } else { return Comparison::Superlist; }
    }

    Comparison::Unequal
}
