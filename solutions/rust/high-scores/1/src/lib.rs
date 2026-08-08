#[derive(Debug)]
pub struct HighScores
{
    scores: Vec<u32>
}

impl HighScores {
    pub fn new(scores: &[u32]) -> Self {
        HighScores {
            scores: scores.into()
        }
    }

    pub fn scores(&self) -> &[u32] {
        &self.scores
    }

    pub fn latest(&self) -> Option<u32> {
        self.scores.last().copied()
    }

    pub fn personal_best(&self) -> Option<u32> {
        self.scores.iter().max().copied()
    }

    pub fn personal_top_three(&self) -> Vec<u32> {
        let n = 3;
        let mut top = self.scores.clone();
        top.sort_unstable_by(|a, b| b.cmp(a));
        top.truncate(n);    
        top
    }
}
