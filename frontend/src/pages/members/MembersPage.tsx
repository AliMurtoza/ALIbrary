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
  createMember,
  deleteMember,
  getMembers,
  updateMember,
} from "../../services/memberService";

import { Member } from "../../types/Member";

export default function MembersPage() {
  const [members, setMembers] = useState<Member[]>([]);
  const [loading, setLoading] = useState(true);

  const [open, setOpen] = useState(false);

  const [editingMember, setEditingMember] = useState<Member | null>(null);
  const [selectedMember, setSelectedMember] = useState<Member | null>(null);

  const [deleteDialogOpen, setDeleteDialogOpen] = useState(false);

  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [userId, setUserId] = useState("");

  useEffect(() => {
    loadMembers();
  }, []);

  async function loadMembers() {
    const result = await getMembers();

    setMembers(result);

    setLoading(false);
  }

  async function handleSave() {
    const request = {
      firstName,
      lastName,
      userId,
    };

    if (editingMember) {
      await updateMember(editingMember.id, request);
    } else {
      await createMember(request);
    }

    setOpen(false);

    window.location.reload();
  }

  function handleEdit(member: Member) {
    setEditingMember(member);

    setFirstName(member.firstName);
    setLastName(member.lastName);
    setUserId(member.userId);

    setOpen(true);
  }

  function handleDelete(member: Member) {
    setSelectedMember(member);

    setDeleteDialogOpen(true);
  }

  async function confirmDelete() {
    if (!selectedMember) return;

    await deleteMember(selectedMember.id);

    window.location.reload();
  }

  if (loading) {
    return <CircularProgress />;
  }

  return (
    <>
      <Typography variant="h4" gutterBottom>
        Members
      </Typography>

      <Button
        variant="contained"
        sx={{ mb: 2 }}
        onClick={() => {
          setEditingMember(null);

          setFirstName("");
          setLastName("");
          setUserId("");

          setOpen(true);
        }}
      >
        Add Member
      </Button>

      <Paper
        elevation={3}
        sx={{
          p: 2,
          bgcolor: "#fafafa",
        }}
      >
        <List>
          {members.map((member) => (
            <ListItem
              key={member.id}
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
                    onClick={() => handleEdit(member)}
                  >
                    <EditIcon />
                  </IconButton>

                  <IconButton
                    color="error"
                    onClick={() => handleDelete(member)}
                  >
                    <DeleteIcon />
                  </IconButton>
                </>
              }
            >
              <ListItemText
                primary={`${member.firstName} ${member.lastName}`}
                secondary={`User ID: ${member.userId}`}
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
          {editingMember ? "Edit Member" : "Add Member"}
        </DialogTitle>

        <DialogContent>
          <TextField
            fullWidth
            margin="normal"
            label="First Name"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            label="Last Name"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
          />

          <TextField
            fullWidth
            margin="normal"
            label="User ID"
            value={userId}
            onChange={(e) => setUserId(e.target.value)}
          />
        </DialogContent>

        <DialogActions>
          <Button onClick={() => setOpen(false)}>Cancel</Button>

          <Button variant="contained" onClick={handleSave}>
            {editingMember ? "Update" : "Save"}
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
            <strong>
              "{selectedMember?.firstName} {selectedMember?.lastName}"
            </strong>
            ?
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
