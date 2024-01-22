import styled from "styled-components";

const StyledPanel = styled.div`
    height: 100%;
`;


const Content = styled.div`
    margin: 20px;
`;

const RightPanel = (props) => {
    return (
        <StyledPanel>
            <Content>
                {props.children}
            </Content>
        </StyledPanel>
    )
}

export default RightPanel;