use std::fmt;

#[derive(Debug, PartialEq, Eq)]
pub struct Clock{
    hours: i32, 
    minutes: i32
}

impl Clock {
    pub fn new(hours: i32, minutes: i32) -> Self {
        let total_minutes = hours * 60 + minutes;
        let minutes_per_day = 24 * 60; // 1440
        
        let mut minutes_modulo = total_minutes % minutes_per_day;
        
        if minutes_modulo < 0 {
            minutes_modulo += minutes_per_day;
        }

        Self {
            hours: minutes_modulo / 60,
            minutes: minutes_modulo % 60,
        }
    }

    pub fn add_minutes(&self, minutes: i32) -> Self {
        Self::new(self.hours, self.minutes + minutes)
    }
}

impl fmt::Display for Clock {
    fn fmt(&self, f: &mut fmt::Formatter<'_>) -> fmt::Result {
        write!(f, "{:02}:{:02}", self.hours, self.minutes)
    }
}