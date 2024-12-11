import { FC } from "react";
import { createBrowserRouter, RouterProvider } from "react-router-dom";
import ListTask from "../pages/ListTask";
import Login from "../pages/Login";
import ContainerPage from "./ContainerPage";
import NewTask from "../pages/NewTask";
import EditTask from "../pages/EditTask";

export const PathRoter = {
  LOGIN: "/",
  TASKS: "/tasks",
  NEW_TASK: "/new/task",
  EDIT_TASK: "/edit/task",
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
  {
    path: PathRoter.NEW_TASK,
    element: (
      <ContainerPage>
        <NewTask />
      </ContainerPage>
    ),
  },
  {
    path: PathRoter.EDIT_TASK,
    element: (
      <ContainerPage>
        <EditTask />
      </ContainerPage>
    ),
  },
]);

const Router: FC = () => <RouterProvider router={router} />;

export default Router;
