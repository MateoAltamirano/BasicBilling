import { Flex, Tabs } from '@chakra-ui/react';
import Content from './components/content';
import Navbar from './components/navbar/Navbar';

const App = () => {
  return (
    <Flex w={'100vw'} h={'100vh'} justifyContent={'center'}>
      <Tabs display={'flex'} w={'100%'}>
        <Navbar />
        <Content />
      </Tabs>
    </Flex>
  );
};

export default App;
