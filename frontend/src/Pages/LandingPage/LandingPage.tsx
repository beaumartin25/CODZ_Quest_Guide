// frontend/src/Pages/LandingPage.tsx
import { useEffect } from "react";
import { useNavigate } from "react-router-dom";

const LandingPage = () => {
  const navigate = useNavigate();

  useEffect(() => {
    navigate("/games");
  }, [navigate]);

  return <div>Landing Page</div>;
};

export default LandingPage;
