pub struct Allergies {
    score: u32,
}

#[derive(Debug, PartialEq, Eq, Copy, Clone)]
pub enum Allergen {
    Eggs          = 1 << 0,
    Peanuts       = 1 << 1,
    Shellfish     = 1 << 2,
    Strawberries  = 1 << 3,
    Tomatoes      = 1 << 4,
    Chocolate     = 1 << 5,
    Pollen        = 1 << 6,
    Cats          = 1 << 7,
}

impl Allergies {
    pub fn new(score: u32) -> Self {
        Allergies { score }
    }

    pub fn is_allergic_to(&self, allergen: &Allergen) -> bool {
        self.allergies().contains(allergen)
    }

    pub fn allergies(&self) -> Vec<Allergen> {
        vec![
            Allergen::Eggs,
            Allergen::Peanuts,
            Allergen::Shellfish,
            Allergen::Strawberries,
            Allergen::Tomatoes,
            Allergen::Chocolate,
            Allergen::Pollen,
            Allergen::Cats,
        ]
        .into_iter()
        .filter(|&a| self.score & (a as u32) != 0)
        .collect()
    }
}
