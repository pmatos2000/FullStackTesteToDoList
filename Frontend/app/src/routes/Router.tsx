import { FC } from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import ListTask from "../pages/ListTask";
import Login from "../pages/Login";
import ContainerPage from "./ContainerPage";

export const PathRoter = {
  LOGIN: "/",
  TASKS: "/tasks",
};

const router = createBrowserRouter([
  {
    path: PathRoter.LOGIN,
    element: (
      <ContainerPage>
        <Login />
      </ContainerPage>
    ),
  },
  {
    path: PathRoter.TASKS,
    element: (
      <ContainerPage>
        <ListTask />
      </ContainerPage>
    ),
  },
]);

const Router: FC = () => <RouterProvider router={router} />;

export default Router;
