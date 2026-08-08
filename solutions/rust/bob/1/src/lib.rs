pub fn reply(message: &str) -> &str {
    let message = message.trim();
    let is_question = message.ends_with('?');
    let has_letters = message.chars().any(|c| c.is_alphabetic());
    let is_yelling = has_letters && message == message.to_uppercase();
    match message {
        _ if message.is_empty() => "Fine. Be that way!",
        _ if is_yelling && is_question => "Calm down, I know what I'm doing!",
        _ if is_yelling => "Whoa, chill out!",
        _ if is_question => "Sure.",
        _ => "Whatever."
    }
}
