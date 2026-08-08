pub fn is_armstrong_number(num: u32) -> bool {
    let count = if num == 0 { 1 } else { num.ilog10() + 1 };

    let mut sum: u32 = 0;
    let mut digits = num;

    while digits > 0 {
        let digit = digits % 10;

        if let Some(pow) = digit.checked_pow(count) {
            if let Some(sum_new) = sum.checked_add(pow) {
                sum = sum_new;
            } else {
                return false;
            }
        } else {
            return false;
        }

        digits /= 10;        
    }

    sum == num
}
