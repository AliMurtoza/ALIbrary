import { useEffect, useState } from "react";

import {
    CircularProgress,
    List,
    ListItem,
    ListItemText,
    Paper,
    Typography,
} from "@mui/material";

import { getBooks } from "../../services/bookService";

import { Book } from "../../types/Book";

export default function BooksPage() {

    const [books, setBooks] = useState<Book[]>([]);

    const [loading, setLoading] = useState(true);

    useEffect(() => {

        async function loadBooks() {

            try {

                const result = await getBooks();

                setBooks(result);

            }
            finally {

                setLoading(false);

            }

        }

        loadBooks();

    }, []);

    if (loading) {

        return <CircularProgress />;

    }

    return (

        <>

            <Typography
                variant="h4"
                gutterBottom
            >
                Books
            </Typography>

            <Paper>

                <List>

                    {books.map(book => (

                        <ListItem key={book.id} divider>

                            <ListItemText

                                primary={book.title}

                                secondary={`${book.isbn} • ${book.publishedYear}`}

                            />

                        </ListItem>

                    ))}

                </List>

            </Paper>

        </>

    );

}