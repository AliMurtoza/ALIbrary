import { useEffect, useState } from "react";

import {
  Button,
  CircularProgress,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  List,
  ListItem,
  ListItemText,
  Paper,
  TextField,
  Typography,
} from "@mui/material";

import { createBook } from "../../services/bookService";

import { getBooks } from "../../services/bookService";

import { Book } from "../../types/Book";

export default function BooksPage() {
  const [books, setBooks] = useState<Book[]>([]);

  const [loading, setLoading] = useState(true);

  const [open, setOpen] = useState(false);

  const [title, setTitle] = useState("");
  const [isbn, setIsbn] = useState("");
  const [description, setDescription] = useState("");

  const [publisherId, setPublisherId] = useState("");
  const [languageId, setLanguageId] = useState("");

  const [publishedYear, setPublishedYear] = useState(2026);

  async function handleCreate() {
    await createBook({
      title,

      isbn,

      description,

      publisherId,

      languageId,

      publishedYear,
    });

    setOpen(false);

    window.location.reload();
  }

  useEffect(() => {
    async function loadBooks() {
      try {
        const result = await getBooks();

        setBooks(result);
      } finally {
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
      <Typography variant="h4" gutterBottom>
        Books
      </Typography>

      <Button variant="contained" sx={{ mb: 2 }} onClick={() => setOpen(true)}>
        Add Book
      </Button>

      <Paper>
        <List>
          {books.map((book) => (
            <ListItem key={book.id} divider>
              <ListItemText
                primary={book.title}
                secondary={`${book.isbn} • ${book.publishedYear}`}
              />
            </ListItem>
          ))}
        </List>
      </Paper>
      <Dialog
        open={open}
        onClose={() => setOpen(false)}
        maxWidth="sm"
        fullWidth
      >
        <DialogTitle>Add Book</DialogTitle>

        <DialogContent>
          <TextField
            fullWidth
            margin="normal"
            label="Title"
            value={title}
            onChange={(e) => setTitle(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            label="ISBN"
            value={isbn}
            onChange={(e) => setIsbn(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            label="Description"
            value={description}
            onChange={(e) => setDescription(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            label="Publisher Id"
            value={publisherId}
            onChange={(e) => setPublisherId(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            label="Language Id"
            value={languageId}
            onChange={(e) => setLanguageId(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            type="number"
            label="Published Year"
            value={publishedYear}
            onChange={(e) => setPublishedYear(Number(e.target.value))}
          />
        </DialogContent>

        <DialogActions>
          <Button onClick={() => setOpen(false)}>Cancel</Button>

          <Button variant="contained" onClick={handleCreate}>
            Save
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
}
