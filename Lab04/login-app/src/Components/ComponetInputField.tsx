 import type { ChangeEventHandler } from 'react'
type InputType = "text" | "password";
interface InputTypeProps {
  label: string;
  type: InputType;
  value: string;
  onChange: ChangeEventHandler<HTMLInputElement>;
  palcerHolder: string;
  error?: string;
}

function InputField({
  label,
  type,
  value,
  onChange,
  palcerHolder,
  error,
}: InputTypeProps) {
  return (
    <div className="input-group">
      <label className="input-label">{label}</label>
      <input
        type={type}
        value={value}
        onChange={onChange}
        placeholder={palcerHolder}
        className={'input-field ${error ? 'input-error' : ''}'}
      />
      {error && <span className="error-msg">{error}</span>}
    </div>
  );
  export default componenetInputField;
}
