import React, { ReactNode } from 'react';
import styled from 'styled-components';
import * as COLORS from '../../constants/Colors';

interface StyledButtonProps {
  variant?: 'primary' | 'secondary';
  size?: 'small' | 'medium' | 'large';
  onClick?: () => void;
}

interface ButtonProps
  extends StyledButtonProps {
  label: string | ReactNode;
}

function GetButtonHeight(size: ButtonProps['size']): number {
  switch (size) {
    case 'small':
      return 40;
    case 'medium':
      return 40;
    case 'large':
      return 50;
    default:
      return 40;
  }
}

function GetButtonWidth(size: ButtonProps['size']): number {
  switch (size) {
    case 'small':
      return 80;
    case 'medium':
      return 120;
    case 'large':
      return 160;
    default:
      return 120;
  }
}

const StyledButton = styled.button<StyledButtonProps>`
  position: relative;
  background: transparent;
  color: inherit;
  border: none;
  height: ${(props) => GetButtonHeight(props.size)}px;
  width: ${(props) => GetButtonWidth(props.size)}px;
  margin: 5px;
  transition: all 0.15s ease;

  &:after {
    content: '';
    position: absolute;
    bottom: 10%;
    left: 50%;
    transform: translateX(-50%);
    width: 0%;
    height: 1px;
    background-color: ${(props) => props.variant === 'primary' ? COLORS.MAIN_THEME_1 : COLORS.MAIN_THEME_2};
    transition: all 0.15s ease;
  }

  &:hover:after {
    width: 30%;
  }

  &:hover{
    color: ${(props) => props.variant === 'primary' ? COLORS.MAIN_THEME_1 : COLORS.MAIN_THEME_2};
  }
`;

const Button: React.FC<ButtonProps> = ({ label, variant = 'secondary', size = 'medium', onClick }) => {
  return (
    <StyledButton onClick={onClick} variant={variant} size={size}>
      {label}
    </StyledButton>
  );
};

export default Button;