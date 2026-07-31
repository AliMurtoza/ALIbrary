export interface Book {
    id: string;
    title: string;
    isbn: string;
    publishedYear: number;
}

export interface CreateBookRequest {
    title: string;
    publisherId: string;
    languageId: string;
    isbn: string;
    publishedYear: number;
    description: string;
}