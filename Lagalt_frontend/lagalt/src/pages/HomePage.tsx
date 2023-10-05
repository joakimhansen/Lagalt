import React, { useEffect, useState } from "react";
import ProjectList from "../components/projects/ProjectList.tsx";
import styled from "styled-components";

const CategoryMenu = styled.div`
  width: 15%;
  list-style: none;
  margin-left: 20px;
  margin-top: 20px;
  display: flex;
  flex-direction: column;

  @media (max-width: 480px) {
    flex-direction: row;
  }
`;

const Wrapper = styled.div`
  display: flex;
  flex-direction: row;

  @media (max-width: 480px) {
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
  const x = [
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

  //Replace the array with actual data from api
  const menuItems = [
    { title: "Spill" },
    { title: "Film" },
    { title: "Webutvikling" },
  ];

  const [categories, setCategories] = useState([]);
  const [projects, setProjects] = useState([]);

  //let apiUrl = "https://lagalt-docker.azurewebsites.net";

  const apiUrl = process.env.REACT_APP_API_URL;
  console.log(apiUrl);

  useEffect(() => {
    fetch(`${apiUrl}/api/v1/categories`)
      .then((response) => response.json())
      .then((data) => setCategories(data))
      .catch((error) => console.error("Error fetching categories", error));
  }, []);

  useEffect(() => {
    fetch(`${apiUrl}/api/v1/projects`)
      .then((response) => response.json())
      .then((data) => setProjects(data))
      .catch((error) => console.error("Error fetching categories", error));
  }, []);

  const [selectedMenuItem, setSelectedMenuItem] = useState(0);

  const handleClick = (index) => {
    setSelectedMenuItem(index);
  };

  const projectsToDisplay = [{}];
  let index;

  return (
    <Wrapper>
      <CategoryMenu>
        {categories &&
          categories.map((c, index) => {
            return (
              <MenuItem
                onClick={() => handleClick(index)}
                selected={selectedMenuItem === index}
                key={index}
              >
                {c.name}
              </MenuItem>
            );
          })}
      </CategoryMenu>

      {projects && projects.map((p) => {
        index = p.categoryId -1; //The API doens't have an ID 0, so we need to force the index to start on 1
        console.log(p);
         if (index === selectedMenuItem) {
          projectsToDisplay.push(p);
          return <></>;
        }
      })}

      <ProjectList projects={projectsToDisplay} />
    </Wrapper>
  );
};
export default HomePage;
