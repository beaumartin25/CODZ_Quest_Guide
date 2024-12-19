import React from "react";
import Card from "../Card/Card";

type Props = {};

const CardList = (props: Props) => {
  return (
    <div>
      <Card gameName={"Black Ops 1"} />
      <Card gameName={"Black Ops 2"} />
      <Card gameName={"Black Ops 3"} />
    </div>
  );
};

export default CardList;
