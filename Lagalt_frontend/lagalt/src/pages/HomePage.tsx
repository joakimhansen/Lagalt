import React, { useState } from "react";
import ProjectList from "../components/projects/ProjectList.tsx";
import styled from "styled-components";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faChevronRight } from "@fortawesome/free-solid-svg-icons";

const TopicMenu = styled.div`
  width: 15%;
  list-style: none;
  margin-left: 20px;
  margin-top: 20px;
  display: flex;
  flex-direction: column;

  @media (max-width: 480px){
    flex-direction: row;
  }
`;

const Wrapper = styled.div`
  display: flex;
  flex-direction: row;

  @media (max-width: 480px){
    flex-direction: column;
  }
`;
const MenuItem = styled.option`
  all: unset;
  font-size: 19px;
  padding: 20px;
  display: flex;
  justify-content: space-between;
  width: 80%;
  border-radius: 15px;
  margin-bottom: 5px;

  background-color: ${(props) => (props.selected ? "#481f70" : "none")};

  &:hover {
    background-color: #28113e;
  }
`;

const HomePage = () => {
  const projects = [
    {
      title: "Prosjekt 0",
      description:
        "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
      owner: "Silje",
      id: 0,
      image: "https://randomuser.me/api/portraits/women/58.jpg",
      categoryID: 0,
    },
    {
      title: "Prosjekt 1",
      description:
        "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
      owner: "Silje",
      id: 1,
      image: "https://randomuser.me/api/portraits/women/58.jpg",
      categoryID: 1,
    },
    {
      title: "Prosjekt 2",
      description:
        "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
      owner: "Joakim",
      id: 2,
      image: "https://randomuser.me/api/portraits/men/30.jpg",
      categoryID: 2,
    },
    {
      title: "Prosjekt 3",
      description:
        "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
      owner: "Magnus",
      id: 3,
      image: "https://randomuser.me/api/portraits/men/73.jpg",
      categoryID: 2,
    },
    {
      title: "Prosjekt 4",
      description:
        "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
      owner: "Silje D",
      id: 4,
      image: "https://randomuser.me/api/portraits/women/44.jpg",
      categoryID: 0,
    },
  ];

  const menuItems = [
    { title: "Spill" },
    { title: "Film" },
    { title: "Webutvikling" },
  ];

  const [selectedMenuItem, setSelectedMenuItem] = useState(0);

  const handleClick = (index) => {
    setSelectedMenuItem(index);
  };

  const projectsToDisplay = [{}];

  return (
    <Wrapper>
      <TopicMenu>
        {menuItems.map((m, index) => {
          return (
            <MenuItem
              onClick={() => handleClick(index)}
              selected={selectedMenuItem === index}
              key={index}
            >
              {m.title}
            </MenuItem>
          );
        })}
      </TopicMenu>

      {projects.map((c) => {
        if (c.categoryID === selectedMenuItem) {
            projectsToDisplay.push(c)
          return <></>;
        }
      })}

      <ProjectList projects={projectsToDisplay} />
    </Wrapper>
  );
};
export default HomePage;