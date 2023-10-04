import React from "react";
import styled from "styled-components";
import ProjectListItem from "./ProjectListItem.tsx";

const StyledProjectList = styled.div`
  width: 50%;
  display: flex;
  margin-left: 20px;
  margin-top: 20px;
  flex-direction: column;
  gap: 20px;
`;

const tests = [
  {
    title: "Prosjekt 1",
    description:
      "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
    owner: "Silje",
    id: 1,
    image: "https://randomuser.me/api/portraits/women/58.jpg",
  },
  {
    title: "Prosjekt 2",
    description:
      "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
    owner: "Joakim",
    id: 2,
    image: "https://randomuser.me/api/portraits/men/30.jpg",
  },
  {
    title: "Prosjekt 3",
    description:
      "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
    owner: "Magnus",
    id: 3,
    image: "https://randomuser.me/api/portraits/men/73.jpg",
  },
  {
    title: "Prosjekt 4",
    description:
      "Prosjektbeskrivelse: Lorem ipsum dolor sit amet consectetur adipisicing elit. Repellendus et tempore ex perspiciatis natus aperiam atque, facere rerum architecto reiciendis!",
    owner: "Silje D",
    id: 4,
    image: "https://randomuser.me/api/portraits/women/44.jpg",
  },
];

const ProjectList = (projects) => {
  return (
    <StyledProjectList>
      {projects.projects.map((p) => {
        if (p.title && p.description && p.owner) {
          return (
            <ProjectListItem
              title={p.title}
              description={p.description}
              owner={p.owner}
              image={p.image}
            />
          );
        }
      })}
    </StyledProjectList>
  );
};
export default ProjectList;
