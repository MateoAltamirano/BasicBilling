import { Flex, Text } from '@chakra-ui/react';
import { FiInbox } from 'react-icons/fi';

const EmptyList = ({ message }: { message: string }) => {
  return (
    <Flex
      flexDir={'column'}
      h={'100%'}
      w={'100%'}
      justifyContent={'center'}
      alignItems={'center'}
    >
      <FiInbox size={'10rem'} color={'#CBD5E0'} />
      <Text fontSize={'1.5rem'} color={'#CBD5E0'}>
        {message}
      </Text>
    </Flex>
  );
};

export default EmptyList;
