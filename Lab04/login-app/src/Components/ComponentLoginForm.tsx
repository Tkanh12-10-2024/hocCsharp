import { useState, type FormEvent } from "react";
import InputField from "./InputFiedl";
export interface LoginPayload {
  username: string;
  password: string;
}

type SubmitHandler = (payload: LoginPayload) => Promise<void> | void;

interface LoginFormProps {
  title: string;
  onSubmit: SubmitHandler;
}

interface LoginErrors {
  username?: string;
  password?: string;
}
function loginFrom({ title, onSubmit }: logingFormProps) {
  const [username, setUserName] = useState<string>("");
  const [password, setPassWord] = useState<string>("");
  const [error, setError] = useState<LoginErrors>({});
}

const validate = () => {
  const newErrors: LoginErrors = {};

  if (!username.trim()) {
    newErrors.username = "Vui lòng nhập username";
  }

  if (!password.trim()) {
    newErrors.password = "Vui lòng nhập mật khẩu";
  }

  return newErrors;
};
