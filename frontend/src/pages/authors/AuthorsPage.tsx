import { useEffect, useState } from "react";

import {
  Button,
  CircularProgress,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  IconButton,
  List,
  ListItem,
  ListItemText,
  Paper,
  TextField,
  Typography,
} from "@mui/material";

import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";

import {
  createAuthor,
  deleteAuthor,
  getAuthors,
  updateAuthor,
} from "../../services/authorService";

import { Author } from "../../types/Author";

export default function AuthorsPage() {
  const [authors, setAuthors] = useState<Author[]>([]);
  const [loading, setLoading] = useState(true);

  const [open, setOpen] = useState(false);

  const [editingAuthor, setEditingAuthor] = useState<Author | null>(null);

  const [selectedAuthor, setSelectedAuthor] = useState<Author | null>(null);

  const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);

  const [displayName, setDisplayName] = useState("");
  const [biography, setBiography] = useState("");

  useEffect(() => {
    loadAuthors();
  }, []);

  async function loadAuthors() {
    const result = await getAuthors();

    setAuthors(result);

    setLoading(false);
  }

  async function handleSave() {
    const request = {
      displayName,
      biography,
    };

    if (editingAuthor) {
      await updateAuthor(editingAuthor.id, request);
    } else {
      await createAuthor(request);
    }

    setOpen(false);

    window.location.reload();
  }

  function handleEdit(author: Author) {
    setEditingAuthor(author);

    setDisplayName(author.displayName);
    setBiography(author.biography);

    setOpen(true);
  }

  function handleDelete(author: Author) {
    setSelectedAuthor(author);

    setDeleteDialogOpen(true);
  }

  async function confirmDelete() {
    if (!selectedAuthor) return;

    await deleteAuthor(selectedAuthor.id);

    window.location.reload();
  }

  if (loading) {
    return <CircularProgress />;
  }

  return (
    <>
      <Typography variant="h4" gutterBottom>
        Authors
      </Typography>

      <Button
        variant="contained"
        sx={{ mb: 2 }}
        onClick={() => {
          setEditingAuthor(null);

          setDisplayName("");
          setBiography("");

          setOpen(true);
        }}
      >
        Add Author
      </Button>

      <Paper
        elevation={3}
        sx={{
          p: 2,
          bgcolor: "#fafafa",
        }}
      >
        <List>
          {authors.map((author) => (
            <ListItem
              key={author.id}
              sx={{
                mb: 1,
                borderRadius: 2,
                bgcolor: "#ffffff",
                border: "1px solid #e0e0e0",
                boxShadow: 1,
              }}
              secondaryAction={
                <>
                  <IconButton
                    color="primary"
                    onClick={() => handleEdit(author)}
                  >
                    <EditIcon />
                  </IconButton>

                  <IconButton
                    color="error"
                    onClick={() => handleDelete(author)}
                  >
                    <DeleteIcon />
                  </IconButton>
                </>
              }
            >
              <ListItemText
                primary={author.displayName}
                secondary={author.biography}
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
        <DialogTitle>
          {editingAuthor ? "Edit Author" : "Add Author"}
        </DialogTitle>

        <DialogContent>
          <TextField
            fullWidth
            margin="normal"
            label="Display Name"
            value={displayName}
            onChange={(e) => setDisplayName(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            multiline
            rows={4}
            label="Biography"
            value={biography}
            onChange={(e) => setBiography(e.target.value)}
          />
        </DialogContent>

        <DialogActions>
          <Button onClick={() => setOpen(false)}>Cancel</Button>

          <Button variant="contained" onClick={handleSave}>
            {editingAuthor ? "Update" : "Save"}
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
            Are you sure you want to delete{" "}
            <strong>"{selectedAuthor?.displayName}"</strong>?
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
