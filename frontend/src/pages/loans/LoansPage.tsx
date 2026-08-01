import { useEffect, useState } from "react";

import {
  Button,
  Chip,
  CircularProgress,
  Dialog,
  DialogActions,
  DialogContent,
  DialogTitle,
  List,
  ListItem,
  ListItemText,
  Paper,
  Typography,
} from "@mui/material";

import { Loan } from "../../types/Loan";

import { getLoans, returnBook } from "../../services/loanService";

export default function LoansPage() {
  const [loans, setLoans] = useState<Loan[]>([]);

  const [loading, setLoading] = useState(true);

  const [returnDialogOpen, setReturnDialogOpen] = useState(false);

  const [selectedLoan, setSelectedLoan] = useState<Loan | null>(null);

  async function loadLoans() {
    try {
      const result = await getLoans();

      setLoans(result);
    } finally {
      setLoading(false);
    }
  }

  useEffect(() => {
    loadLoans();
  }, []);

  async function confirmReturn() {
    if (!selectedLoan) return;

    await returnBook(selectedLoan.id);

    setReturnDialogOpen(false);

    setSelectedLoan(null);

    await loadLoans();
  }

  if (loading) {
    return <CircularProgress />;
  }

  return (
    <>
      <Typography variant="h4" gutterBottom>
        Loans
      </Typography>

      <Paper sx={{ p: 2 }}>
        <List>
          {loans.map((loan) => (
            <Paper
              key={loan.id}
              elevation={1}
              sx={{
                mb: 2,
                p: 2,
                bgcolor: "#fafafa",
              }}
            >
              <ListItem
                disablePadding
                secondaryAction={
                  loan.status === 0 ? (
                    <Button
                      color="warning"
                      variant="outlined"
                      onClick={() => {
                        setSelectedLoan(loan);
                        setReturnDialogOpen(true);
                      }}
                    >
                      Return
                    </Button>
                  ) : null
                }
              >
                <ListItemText
                  primary={loan.bookTitle}
                  secondary={
                    <>
                      Member: {loan.memberName}
                      <br />
                      Barcode: {loan.barcode}
                      <br />
                      Borrowed: {new Date(loan.borrowedAt).toLocaleDateString()}
                      <br />
                      Due: {new Date(loan.dueAt).toLocaleDateString()}
                      <br />
                      {loan.returnedAt && (
                        <>
                          Returned:{" "}
                          {new Date(loan.returnedAt).toLocaleDateString()}
                          <br />
                        </>
                      )}
                      <br />
                      <Chip
                        size="small"
                        label={loan.status === 0 ? "Active" : "Returned"}
                        color={loan.status === 0 ? "success" : "default"}
                      />
                    </>
                  }
                />
              </ListItem>
            </Paper>
          ))}
        </List>
      </Paper>

      <Dialog
        open={returnDialogOpen}
        onClose={() => setReturnDialogOpen(false)}
      >
        <DialogTitle>Return Book</DialogTitle>

        <DialogContent>
          <Typography>
            Return <strong>{selectedLoan?.bookTitle}</strong>?
          </Typography>
        </DialogContent>

        <DialogActions>
          <Button onClick={() => setReturnDialogOpen(false)}>Cancel</Button>

          <Button variant="contained" color="warning" onClick={confirmReturn}>
            Return
          </Button>
        </DialogActions>
      </Dialog>
    </>
  );
}
