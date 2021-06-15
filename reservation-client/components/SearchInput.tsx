import React from 'react';
import { StyleSheet, TextInput as RnTextInput } from 'react-native';

type SearchInputProps = {
  value?: string;
  onChange?(text: string): void;
  placeholder?: string;
}

export function SearchInput(props: SearchInputProps) {
  // const [searchValue, onChangeSearchValue] = React.useState(null);

  const { value, onChange, placeholder } = props;
  
  return <RnTextInput placeholder={placeholder} value={value} onChangeText={onChange} style={styles.input} />;
}

const styles = StyleSheet.create({
  input: {
    flex: 1,
    backgroundColor: 'white',
    padding: 8,
    borderRadius: 5,
    fontSize: 28
    // height: 40,
    // margin: 12,
    // borderWidth: 1,
    // padding: 2,
  },
});
