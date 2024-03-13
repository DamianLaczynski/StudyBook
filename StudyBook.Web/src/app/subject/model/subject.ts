import { FlashcardSet } from "../components/flashcard/model/flashcard-set"
import { Test } from "../components/test/model/test"

export interface Subject {
    id: number,
    name: string,
    description: string
    flashcardSets: FlashcardSet[],
    tests: Test[]
}
