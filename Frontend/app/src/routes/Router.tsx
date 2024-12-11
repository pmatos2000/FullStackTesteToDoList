import { FC } from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import ListTask from "../pages/ListTask";
import Login from "../pages/Login";

export const PathRoter = {
  LOGIN: "/",
  TASKS: "/tasks",
};

const router = createBrowserRouter([
  { path: PathRoter.LOGIN, element: <Login /> },
  { path: PathRoter.TASKS, element: <ListTask /> },
]);

const Router: FC = () => <RouterProvider router={router} />;

export default Router;
