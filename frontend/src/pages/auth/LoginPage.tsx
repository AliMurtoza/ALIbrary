import { useState } from "react";

import {
    Button,
    Card,
    CardContent,
    Container,
    TextField,
    Typography,
} from "@mui/material";

import { login } from "../../services/authService";

export default function LoginPage() {

    const [email, setEmail] = useState("");

    const [password, setPassword] = useState("");

    async function handleLogin() {

        try {

            const result = await login({
                email,
                password,
            });

            localStorage.setItem(
                "token",
                result.token
            );

            alert("Login successful");

        } catch {

            alert("Login failed");

        }

    }

    return (

        <Container maxWidth="sm" sx={{ mt: 8 }}>

            <Card>

                <CardContent>

                    <Typography
                        variant="h4"
                        gutterBottom
                    >
                        Login
                    </Typography>

                    <TextField
                        label="Email"
                        fullWidth
                        margin="normal"
                        value={email}
                        onChange={(e) =>
                            setEmail(e.target.value)
                        }
                    />

                    <TextField
                        label="Password"
                        type="password"
                        fullWidth
                        margin="normal"
                        value={password}
                        onChange={(e) =>
                            setPassword(e.target.value)
                        }
                    />

                    <Button
                        variant="contained"
                        fullWidth
                        sx={{ mt: 2 }}
                        onClick={handleLogin}
                    >
                        Login
                    </Button>

                </CardContent>

            </Card>

        </Container>

    );
}