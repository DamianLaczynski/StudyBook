import { Flashcard } from "./flashcard";

export interface FlashcardSet {
    id: number ,
    name: string,
    description: string,
    flashcards: Flashcard[]
}
