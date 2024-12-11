import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import Router from "./routes/Router";
import App from "./App";

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <App>
      <Router />
    </App>
  </StrictMode>
);
