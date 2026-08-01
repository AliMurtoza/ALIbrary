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
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  IconButton,
} from "@mui/material";

import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";

import {
  createBook,
  deleteBook,
  getBooks,
  updateBook,
} from "../../services/bookService";
import { Book } from "../../types/Book";
import { Lookup } from "../../types/Lookup";

import {
  getPublishers,
  getLanguages,
  getCategories,
} from "../../services/lookupService";

export default function BooksPage() {
  const [books, setBooks] = useState<Book[]>([]);

  const [loading, setLoading] = useState(true);

  const [open, setOpen] = useState(false);

  const [title, setTitle] = useState("");
  const [isbn, setIsbn] = useState("");
  const [description, setDescription] = useState("");

  const [publisherId, setPublisherId] = useState("");
  const [languageId, setLanguageId] = useState("");
  const [categoryId, setCategoryId] = useState("");

  const [publishers, setPublishers] = useState<Lookup[]>([]);
  const [languages, setLanguages] = useState<Lookup[]>([]);
  const [categories, setCategories] = useState<Lookup[]>([]);

  const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);
  const [selectedBook, setSelectedBook] = useState<Book | null>(null);

  const [editingBook, setEditingBook] = useState<Book | null>(null);

  const [publishedYear, setPublishedYear] = useState(2026);

  async function handleSave() {
    const request = {
      title,
      isbn,
      description,
      publisherId,
      languageId,
      categoryId,
      publishedYear,
    };

    if (editingBook) {
      await updateBook(editingBook.id, request);
    } else {
      await createBook(request);
    }

    setOpen(false);

    window.location.reload();
  }

  function handleDelete(book: Book) {
    setSelectedBook(book);
    setDeleteDialogOpen(true);
  }

  async function confirmDelete() {
    if (!selectedBook) return;
    await deleteBook(selectedBook.id);
    setDeleteDialogOpen(false);
    window.location.reload();
  }

  function handleEdit(book: Book) {
    setEditingBook(book);

    setTitle(book.title);
    setIsbn(book.isbn);
    setDescription(book.description);

    setPublisherId(book.publisherId);
    setLanguageId(book.languageId);
    setCategoryId(book.categoryId);

    setPublishedYear(book.publishedYear);

    setOpen(true);
  }

  useEffect(() => {
    async function loadBooks() {
      try {
        const booksResult = await getBooks();
        setBooks(booksResult);

        const publishersResult = await getPublishers();
        setPublishers(publishersResult);

        const languagesResult = await getLanguages();
        setLanguages(languagesResult);

        const categoriesResult = await getCategories();
        setCategories(categoriesResult);
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

      <Button
        variant="contained"
        sx={{ mb: 2 }}
        onClick={() => {
          setEditingBook(null);

          setTitle("");
          setIsbn("");
          setDescription("");

          setPublisherId("");
          setLanguageId("");
          setCategoryId("");

          setPublishedYear(2026);

          setOpen(true);
        }}
      >
        Add Book
      </Button>

      <Paper>
        <List>
          {books.map((book) => (
            <ListItem
              key={book.id}
              divider
              secondaryAction={
                <>
                  <IconButton color="primary" onClick={() => handleEdit(book)}>
                    <EditIcon />
                  </IconButton>

                  <IconButton color="error" onClick={() => handleDelete(book)}>
                    <DeleteIcon />
                  </IconButton>
                </>
              }
            >
              <ListItemText
                primary={book.title}
                secondary={
                  <>
                    {book.isbn} • {book.publishedYear}
                    <br />
                    {book.publisherName} • {book.languageName} •{" "}
                    {book.categoryName}
                  </>
                }
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
        <DialogTitle>{editingBook ? "Edit Book" : "Add Book"}</DialogTitle>

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

          <FormControl fullWidth margin="normal">
            <InputLabel>Category</InputLabel>

            <Select
              value={categoryId}
              label="Category"
              onChange={(e) => setCategoryId(e.target.value)}
            >
              {categories.map((category) => (
                <MenuItem key={category.id} value={category.id}>
                  {category.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>

          <FormControl fullWidth margin="normal">
            <InputLabel>Publisher</InputLabel>

            <Select
              value={publisherId}
              label="Publisher"
              onChange={(e) => setPublisherId(e.target.value)}
            >
              {publishers.map((publisher) => (
                <MenuItem key={publisher.id} value={publisher.id}>
                  {publisher.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>

          <FormControl fullWidth margin="normal">
            <InputLabel>Language</InputLabel>

            <Select
              value={languageId}
              label="Language"
              onChange={(e) => setLanguageId(e.target.value)}
            >
              {languages.map((language) => (
                <MenuItem key={language.id} value={language.id}>
                  {language.name}
                </MenuItem>
              ))}
            </Select>
          </FormControl>

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

          <Button variant="contained" onClick={handleSave}>
            {editingBook ? "Update" : "Save"}
          </Button>
        </DialogActions>
      </Dialog>

      <Dialog
        open={deleteDialogOpen}
        onClose={() => setDeleteDialogOpen(false)}
      >
        <DialogTitle>Confirm Delete</DialogTitle>

        <DialogContent>
          <Typography>
            Are you sure you want to delete
            <strong> "{selectedBook?.title}"</strong>?
          </Typography>
        </DialogContent>

        <DialogActions>
          <Button onClick={() => setDeleteDialogOpen(false)}>Cancel</Button>

          <Button color="error" variant="contained" onClick={confirmDelete}>
            Delete
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
}
