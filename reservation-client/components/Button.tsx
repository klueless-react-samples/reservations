import React from 'react';
import { Button as RnButton, Touchable } from 'react-native';
import { StyleSheet, TouchableHighlight, View, Text } from 'react-native';

// title: string
// variant: standard / confirm / error
type ButtonProps = {
  title: string;
  onPress: () => void;
  variant?: 'standard' | 'confirm' | 'error';
}

const boarderRadius = 5;

export function Button(props: ButtonProps) {
  const { title, variant = 'standard', onPress } = props;

  return <TouchableHighlight
            onPress={onPress}
            style={{borderRadius: boarderRadius}}>

            <View style={styles.button}>
              <Text style={styles.text}>{title}</Text>
            </View>
          </TouchableHighlight>
}

const styles = StyleSheet.create({
  button: {
    backgroundColor: 'white',
    padding: 8,
    boarderRadius: boarderRadius,
  },
  text: {
    fontSize: 28,
  },
});
