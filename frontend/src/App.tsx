import {
    Button,
    Card,
    CardContent,
    Container,
    Typography,
} from "@mui/material";

function App() {
    return (
        <Container maxWidth="md" sx={{ mt: 8 }}>
            <Card elevation={3}>
                <CardContent>

                    <Typography
                        variant="h3"
                        gutterBottom
                    >
                        ALIbrary
                    </Typography>

                    <Typography
                        variant="body1"
                        sx={{ mb: 3 }}
                    >
                        Library Management System
                    </Typography>

                    <Button
                        variant="contained"
                    >
                        Material UI Configured Successfully
                    </Button>

                </CardContent>
            </Card>
        </Container>
    );
}

export default App;