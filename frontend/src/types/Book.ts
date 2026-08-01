export interface Book {
    id: string;
    title: string;
    isbn: string;
    publishedYear: number;
    description: string;

    categoryId: string;
    categoryName: string;

    publisherId: string;
    publisherName: string;

    languageId: string;
    languageName: string;

    authors: string[];
}

export interface CreateBookRequest {
    title: string;
    categoryId: string;
    publisherId: string;
    languageId: string;
    isbn: string;
    publishedYear: number;
    description: string;
}

export interface UpdateBookRequest {
    title: string;
    categoryId: string;
    publisherId: string;
    languageId: string;
    isbn: string;
    publishedYear: number;
    description: string;
}