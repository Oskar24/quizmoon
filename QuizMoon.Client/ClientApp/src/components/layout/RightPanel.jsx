import styled from "styled-components";



const Content = styled.div`
    margin: 20px;
`;

const RightPanel = (props) => {
    return (
        <Content>
            {props.children}
        </Content>
    )
}

export default RightPanel;