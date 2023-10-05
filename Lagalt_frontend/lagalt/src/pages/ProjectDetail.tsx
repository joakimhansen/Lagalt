import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import ProjectListItem from "../components/projects/ProjectListItem.tsx";
import styled from "styled-components";
import DetailedProject from "../components/projects/DetailedProject.tsx";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faChevronLeft } from "@fortawesome/free-solid-svg-icons";
import { Link } from "react-router-dom";

const Wrapper = styled.div`
 
  display: flex;
  justify-content: center;
  margin-left: 50px;
  margin-right: 50px;
  flex-direction: column;
overflow: hidden;`;

const Project = styled.div`

`;

const Button = styled.button`
  all: unset;
  background-color: #7834bb;
  border-radius: 20px;
  width: 40px;
  height: 40px;
  color: white;
  display: flex;
  justify-content: center;
  align-items: center;
  margin-bottom: 30px;

  &:hover {
    background-color: #975dd2;
  }
  a{
    color: white;
  }
`;

// const Container = styled.div`
//   margin-left: 50px;
//   margin-right: 50px;
//   display: flex;
//   flex-direction: column;
// `;

const ProjectDetail = () => {
  const { id } = useParams();
  const [project, setProject] = useState(null);

  useEffect(() => {
    // Simulate fetching project data from an API using the project ID
    fetch(`/api/projects/${id}`)
      .then((response) => response.json())
      .then((data) => setProject(data))
      .catch((error) => console.error("Error fetching project data: ", error));
  }, [id]);

  return (
    <>
      <div>Project Details:</div>
      <div>Id: {id}</div>
     

      <Wrapper>
      <Button>
        <Link to="/">
          <FontAwesomeIcon icon={faChevronLeft} />
        </Link>
      </Button>
        <Project>
          <DetailedProject
            title={"Test"}
            longDescription={
              "Lorem ipsum dolor sit amet consectetur adipisicing elit. Corrupti, repudiandae. Lorem ipsum, dolor sit amet consectetur adipisicing elit. Nisi, repellendus numquam. Id cum reiciendis iste doloribus laudantium delectus, architecto, vel eaque exercitationem cumque amet excepturi. Ipsum impedit unde maiores, officiis expedita illum necessitatibus sint temporibus voluptatem, pariatur itaque dolore repudiandae aperiam molestiae tempore tenetur hic nesciunt inventore at dolores veritatis."
            }
            owner={"JC Baily"}
            image={"https://randomuser.me/api/portraits/men/43.jpg"}
            id={id}
            githubUrl={"https://github.com/"}
          />
        </Project>
      </Wrapper>
      {/* {project ? (
        <div> */}
      {/* <div>{project.title}</div>
          <div>{project.description}</div> */}

      {/* </div>
      ) : (
        <div>Loading project details...</div>
      )} */}
    </>
  );
};

export default ProjectDetail;
