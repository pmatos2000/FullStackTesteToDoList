import { FC } from "react";
import { useNavigate } from "react-router-dom";
import globalRouter from "../routes/globalRouter";

interface ContainerPageProps {
  children?: React.ReactNode;
}

const ContainerPage: FC<ContainerPageProps> = ({ children }) => {
  const navigate = useNavigate();
  globalRouter.navigate = navigate;

  return <div>{children}</div>;
};

export default ContainerPage;
