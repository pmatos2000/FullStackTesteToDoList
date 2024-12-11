import { FC } from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import ListTask from "../pages/ListTask";
import Login from "../pages/Login";

const router = createBrowserRouter([
  { path: "/", element: <Login /> },
  { path: "/tasks", element: <ListTask /> },
]);

const Router: FC = () => <RouterProvider router={router} />;

export default Router;
