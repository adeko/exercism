pub fn annotate(garden: &[&str]) -> Vec<String> {
    let mut grid: Vec<Vec<char>> = garden
        .iter()
        .map(|s| s.chars().collect())
        .collect();
    let height = grid.len();
    
    for row in 0..height {
        let width = grid[row].len();
        
        for position in 0..width {
            if grid[row][position] == ' ' {
                let mut counter = 0;
                
                for row_n in -1..=1 {
                    for position_n in -1..=1 {
                        if position_n == 0 && row_n == 0 {
                            continue;
                        }
                        
                        let target_row = (row as isize) + row_n;
                        let target_position = (position as isize) + position_n;
                        
                        if target_row >= 0 && (target_row as usize) < height {
                            let current_row = &grid[target_row as usize];

                            if target_position >= 0 && (target_position as usize) < current_row.len() {
                                if current_row[target_position as usize] == '*' {
                                    counter += 1;
                                }
                            }
                        }
                    }
                }
                
                if counter > 0 {
                    grid[row][position] = char::from_digit(counter, 10).unwrap();
                }
            }
        }
    }
    
    grid.into_iter()
        .map(|chars| chars.into_iter().collect())
        .collect()
}
